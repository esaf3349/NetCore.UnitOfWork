namespace NetCore.UnitOfWork.WebApi.Common.Pagination
{
    public class PageParams
    {
        private int _pageNumber = 1;
        private int _pageSize = 20;

        public int PageNumber
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                _pageNumber = value <= 0 ? 1 : value;
            }
        }

        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = value <= 0 ? 20 : value;
            }
        }
    }
}
