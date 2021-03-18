export interface IPagedResult<TVM> {
    totalElements:number,
    totalPages:number,
    currentPage:number,
    pageSize:number,
    pages:number,
    result:TVM[]
}