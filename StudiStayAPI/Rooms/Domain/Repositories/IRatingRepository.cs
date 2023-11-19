using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories
{
    /// <summary>
    /// Define las operaciones CRUD para Rating
    /// </summary>
    public interface IRatingRepository
    {
        /// <summary>
        /// Obtiene todos los ratings
        /// </summary>
        Task<IEnumerable<Rating>> ListAsync();
        
        /// <summary>
        /// Agrega un rating
        /// </summary>
        /// <param name="rating">Rating a agregar</param>
        Task AddAsync(Rating rating);
        
        /// <summary>
        /// Encuentra un rating por su id
        /// </summary>
        /// <param name="ratingId">Id del rating a buscar</param>
        Task<Rating> FindByIdAsync(int ratingId);
        
        /// <summary>
        /// Encuentra ratings por el id de la lista de ratings
        /// </summary>
        /// <param name="ratingListId">Id de la lista de ratings</param>
        Task<IEnumerable<Rating>> FindByRatingListIdAsync(int ratingListId);
        
        /// <summary>
        /// Actualiza un rating
        /// </summary>
        /// <param name="rating">Rating a actualizar</param>
        void Update(Rating rating);
        
        /// <summary>
        /// Elimina un rating
        /// </summary>
        /// <param name="rating">Rating a eliminar</param>
        void Remove(Rating rating);
    }
}
