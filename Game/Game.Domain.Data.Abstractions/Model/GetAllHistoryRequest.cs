namespace Game.Domain.Data.Abstractions.Model
{
    /// <summary>
    /// Model class for getting history data from repository
    /// </summary>
    public class GetAllHistoryModel
    {
        /// <summary>
        /// Initial offset for pagination
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Maximum number of rows per page
        /// </summary>
        public int PageSize { get; set; }
    }
}
