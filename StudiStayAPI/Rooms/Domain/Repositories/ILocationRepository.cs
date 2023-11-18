using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Rooms.Domain.Repositories
{
    /// <summary>
    /// Define las operaciones CRUD para Location
    /// </summary>
    public interface ILocationRepository
    {
        /// <summary>
        /// Obtiene todas las ubicaciones
        /// </summary>
        Task<IEnumerable<Location>> ListAsync();
        
        /// <summary>
        /// Agrega una ubicación
        /// </summary>
        /// <param name="location">Ubicación a agregar</param>
        Task AddAsync(Location location);
        
        /// <summary>
        /// Encuentra una ubicación por su id
        /// </summary>
        /// <param name="id">Id de la ubicación a buscar</param>
        Task<Location> FindByIdAsync(int id);
        
        /// <summary>
        /// Encuentra una ubicación por su dirección
        /// </summary>
        /// <param name="address">Dirección de la ubicación a buscar</param>
        Task<Location> FindByAddressAsync(string address);
        
        /// <summary>
        /// Encuentra una ubicación por el código postal de un post asociado
        /// </summary>
        /// <param name="zipCode">Código postal del post asociado a la ubicación a buscar</param>
        Task<Location> FindByZipCodeAsync(string zipCode);
        
        /// <summary>
        /// Actualiza una ubicación
        /// </summary>
        /// <param name="location">Ubicación a actualizar</param>
        void Update(Location location);
        
        /// <summary>
        /// Elimina una ubicación
        /// </summary>
        /// <param name="location">Ubicación a eliminar</param>
        void Remove(Location location);
    }
}
