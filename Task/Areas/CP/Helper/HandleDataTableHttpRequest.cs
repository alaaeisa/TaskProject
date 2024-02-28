
using TaskProject.Infrastructure.DTO;

namespace TaskProject.Areas.CP.Helper
{
    public class HandleDataTableHttpRequest
    {
        public HandleDataTableHttpRequest()
        {

        }
        public static DataTableParamterDTO HandleRequet(HttpRequest request)
        {
            var draw = request.Form["draw"].FirstOrDefault();
            var start = request.Form["start"].FirstOrDefault();
            var length = request.Form["length"].FirstOrDefault();
            var column = request.Form["order[0][column]"].FirstOrDefault();
            var sortColumn = request.Form["columns[" + column + "][data]"].FirstOrDefault();
            if (!string.IsNullOrEmpty(sortColumn))
                sortColumn = char.ToUpper(sortColumn[0]) + sortColumn.Substring(1);
            var sortColumnDirection = request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = request.Form["search[value]"].FirstOrDefault();
            int pageSize = length != null ? (length == "-1" ? -1 : int.Parse(length)) : 0;
            DataTableParamterDTO dataTableParamter = new DataTableParamterDTO()
            {
                Draw = draw ?? "",
                StartRec = start != null ? Convert.ToInt32(start) : 0,
                Order = sortColumn ?? "",
                OrderDir = sortColumnDirection ?? "",
                Search = searchValue ?? "",
                PageSize = pageSize,
                IsArabic = true
            };
            return dataTableParamter;
        }
    }
}
