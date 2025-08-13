namespace Game.Domain.DTO.Base
{
    /// <summary>
    /// Interface to extend DTO request classes with pagination details
    /// </summary>
    public abstract class PaginationFilterRequest
    {
        const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
