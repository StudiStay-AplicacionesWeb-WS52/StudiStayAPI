using StudiStayAPI.Rooms.Domain.Models;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;

namespace StudiStayAPI.Rooms.Services;

public class ReservationService : IReservationService
{
    private readonly IReservationRepository reservationRepository;
    private readonly IUserRepository userRepository;
    private readonly IPostRepository postRepository;
    private readonly IUnitOfWork unitOfWork;
    
    //inyeccion de dependencias
    public ReservationService(IReservationRepository reservationRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IPostRepository postRepository)
    {
        this.reservationRepository = reservationRepository;
        this.userRepository = userRepository;
        this.postRepository = postRepository;
        this.unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Reservation>> ListByPostIdAsync(int postId)
    {
        return await reservationRepository.ListByPostIdAsync(postId);
    }

    public async Task<IEnumerable<Reservation>> ListByUserIdAsync(int userId)
    {
        return await reservationRepository.ListByUserIdAsync(userId);
    }

    public async Task<ReservationApiResponse> GetByIdAsync(int reservationId)
    {
        var existingReservation = await reservationRepository.FindByIdAsync(reservationId);
        if (existingReservation == null) return new ReservationApiResponse("Reservation not found.");
        return new ReservationApiResponse(existingReservation);
    }

    public async Task<ReservationApiResponse> SaveAsync(Reservation reservation)
    {
        //valida si la fecha de checkin y checkout sea correcta
        if (reservation.CheckInDate >= reservation.CheckOutDate) return new ReservationApiResponse("Invalid dates");
        
        //valida el userId
        var existingUser = await userRepository.FindByIdAsync(reservation.UserId);
        if (existingUser == null) return new ReservationApiResponse("Invalid User");

        //valida el postId
        var existingPost = await postRepository.FindByIdAsync(reservation.PostId);
        if (existingPost == null) return new ReservationApiResponse("Invalid Post");
        
        //valida si la reserva esta disponible
        var available = await reservationRepository.isAvailableAsync(reservation.PostId, reservation.CheckInDate, reservation.CheckOutDate);
        if (!available) return new ReservationApiResponse("Reservation not available, please select another date.");
        
        //agrega el precio total de la reserva y las horas de estadia
        reservation.StayHours = (reservation.CheckOutDate - reservation.CheckInDate).Hours;
        reservation.TotalPrice = (decimal)existingPost.Price * reservation.StayHours;
        
        try
        {
            await reservationRepository.AddAsync(reservation);
            await unitOfWork.CompleteAsync();
            return new ReservationApiResponse(reservation);
        }
        catch (Exception e)
        {
            return new ReservationApiResponse($"An error occurred when saving the reservation: {e.Message}");
        }
    }

    public async Task<ReservationApiResponse> UpdateAsync(int reservationId, Reservation reservation)
    {
        //valida si la fecha de checkin y checkout sea correcta
        if (reservation.CheckInDate >= reservation.CheckOutDate) return new ReservationApiResponse("Invalid dates");
        
        //valida si existe la reserva
        var existingReservation = await reservationRepository.FindByIdAsync(reservationId);
        if (existingReservation == null) return new ReservationApiResponse("Reservation not found.");
        
        //valida si existe el userId
        var existingUser = await userRepository.FindByIdAsync(reservation.UserId);
        if (existingUser == null) return new ReservationApiResponse("Invalid User");
        
        //valida el postId
        var existingPost = await postRepository.FindByIdAsync(reservation.PostId);
        if (existingPost == null) return new ReservationApiResponse("Invalid Post");
        
        //valida si la reserva esta disponible
        var available = await reservationRepository.isAvailableAsync(reservation.PostId, reservation.CheckInDate, reservation.CheckOutDate);
        if (!available) return new ReservationApiResponse("Reservation not available, please select another date.");
        
        //modifica los datos de la reserva
        existingReservation.CheckInDate = reservation.CheckInDate;
        existingReservation.CheckOutDate = reservation.CheckOutDate;
        
        try
        {
            reservationRepository.Update(existingReservation);
            await unitOfWork.CompleteAsync();
            return new ReservationApiResponse(existingReservation);
        }
        catch (Exception e)
        {
            return new ReservationApiResponse($"An error occurred when updating the reservation: {e.Message}");
        }
    }

    public async Task<ReservationApiResponse> DeleteAsync(int reservationId)
    {
        var existingReservation = await reservationRepository.FindByIdAsync(reservationId);
        if (existingReservation == null) return new ReservationApiResponse("Reservation not found.");
        
        try
        {
            reservationRepository.Remove(existingReservation);
            await unitOfWork.CompleteAsync();
            return new ReservationApiResponse(existingReservation);
        }
        catch (Exception e)
        {
            return new ReservationApiResponse($"An error occurred when deleting the reservation: {e.Message}");
        }
    }
}