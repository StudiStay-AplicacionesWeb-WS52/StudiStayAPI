using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;
using StudiStayAPI.Security.Domain.Repositories;

namespace StudiStayAPI.Rooms.Services;

/// <summary>
/// Clase que implementa la interfaz IPostService
/// </summary>
public class PostService : IPostService
{
    private readonly IPostRepository postRepository;
    private readonly IUserRepository userRepository;
    private readonly IUnitOfWork unitOfWork;
    
    //inyeccion de dependencias
    public PostService(IPostRepository postRepository, IUserRepository userRepository, ILocationRepository locationRepository, IUnitOfWork unitOfWork)
    {
        this.postRepository = postRepository;
        this.userRepository = userRepository;
        this.unitOfWork = unitOfWork;
        this.locationRepository = locationRepository
    }
    
    public async Task<IEnumerable<Post>> ListAsync()
    {
        return await postRepository.ListAsync();
    }
    
    public async Task<PostApiResponse> GetByIdAsync(int postId)
    {
        var existingPost = await postRepository.FindByIdAsync(postId);
        if (existingPost == null) return new PostApiResponse("Post not found.");
        return new PostApiResponse(existingPost);
    }

    public async Task<IEnumerable<Post>> ListByUserIdAsync(int userId)
    {
        return await postRepository.FindByUserIdAsync(userId);
    }

    public async Task<PostApiResponse> SaveAsync(Post post)
    {
        //valida el userId
        var existingUser = await userRepository.FindByIdAsync(post.UserId);
        if (existingUser == null) return new PostApiResponse("Invalid User");
        
        //valida el titulo que no se repita
        var existingPostWithTitle = await postRepository.FindByTitleAsync(post.Title);
        if (existingPostWithTitle != null) return new PostApiResponse("Post title already exists.");
        
        try
        {
            //guarda el post
            await postRepository.AddAsync(post);
            //completa la transaccion
            await unitOfWork.CompleteAsync();
            //retorna el post como response
            return new PostApiResponse(post);
        }
        catch (Exception e)
        {
            return new PostApiResponse($"An error occurred while saving the post: {e.Message}");
        }
    }

    public async Task<PostApiResponse> UpdateAsync(int postId, Post post)
    {
        //valida si existe el post
        var existingPost = await postRepository.FindByIdAsync(postId);
        if (existingPost == null) return new PostApiResponse("Post not found.");
        
        //valida si existe el userId
        var existingUser = await userRepository.FindByIdAsync(post.UserId);
        if (existingUser == null) return new PostApiResponse("Invalid User");
        
        //valida si el titulo ya existe y no es el mismo post
        var existingPostWithTitle = await postRepository.FindByTitleAsync(post.Title);
        if (existingPostWithTitle != null && existingPostWithTitle.Id != existingPost.Id) 
            return new PostApiResponse("Post title already exists.");
        
        //modifica el post
        existingPost.Title = post.Title ?? existingPost.Title;
        existingPost.Description = post.Description ?? existingPost.Description;
        existingPost.Price = post.Price;
        existingPost.Address = post.Address ?? existingPost.Address;
        existingPost.Rating = post.Rating;
        existingPost.ImageUrl = post.ImageUrl ?? existingPost.ImageUrl;
        existingPost.NearestUniversities = post.NearestUniversities ?? existingPost.NearestUniversities;

        try
        {
            postRepository.Update(existingPost);
            await unitOfWork.CompleteAsync();
            return new PostApiResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostApiResponse($"An error occurred while updating the post: {e.Message}");
        }
    }

    public async Task<PostApiResponse> DeleteAsync(int postId)
    {
        //valida si existe el post
        var existingPost = await postRepository.FindByIdAsync(postId);
        if (existingPost == null) return new PostApiResponse("Post not found.");

        try
        {
            postRepository.Remove(existingPost);
            await unitOfWork.CompleteAsync();
            return new PostApiResponse(existingPost);
        }
        catch (Exception e)
        {
            return new PostApiResponse($"An error occurred while deleting the post: {e.Message}");
        }
    }
}