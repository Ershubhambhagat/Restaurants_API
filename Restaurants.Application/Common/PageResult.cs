namespace Restaurants.Application.Common;

public class PageResult<T>
{
    public PageResult(IEnumerable<T> item,int totalCount,int PageSize,int PageNumber)
    {
        Items = item;
        TotalItemCount = totalCount;
        TotalPage=(int)Math.Ceiling(totalCount/(double)PageSize);
        ItemFrom=PageSize*(PageNumber-1)+1;
        ItemTo = ItemFrom + PageSize - 1;
        //Page size =5,Page no =2
        //skip:PageSize*(Pagenumber-1)=>5
        //itemFrom:5+1=>6
        //ItemTo:6+5-1=10    
    }
    public IEnumerable<T> Items { get; set; }
    public int TotalPage { get; set; }
    public int TotalItemCount { get; set; }
    public int ItemFrom { get; set; }
    public int ItemTo { get; set; } = 0;
}