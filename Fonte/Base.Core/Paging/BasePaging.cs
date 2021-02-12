using System;
using System.Collections.Generic;
using System.Linq;
using Base.Core.Extensions;

namespace Base.Core.Paging
{
    public class BasePaging<TDto> where TDto : class
    {
        protected Page<TDto> SetPage(IList<TDto> dto, int pageCount, int pageSize)
        {
            return SetFormat(dto, pageCount, pageSize);
        }

        protected Page<TDto> SetPage(IList<TDto> dto, int pageCount, int pageSize, List<Order> orders)
        {
            IEnumerable<TDto> result = dto.AsQueryable().OrderBy(SetOrder(orders)).ToList();

            return SetFormat(result, pageCount, pageSize);
        }

        protected Page<TDto> SetPage(IQueryable<TDto> dto, int pageCount, int pageSize) 
        {
            return SetFormat(dto, pageCount, pageSize);
        }

        protected Page<TDto> SetPage(IQueryable<TDto> dto, int pageCount, int pageSize, List<Order> orders)
        {
            IEnumerable<TDto> result = dto.OrderBy(SetOrder(orders)).ToList();

            return SetFormat(result, pageCount, pageSize);
        }

        private Page<TDto> SetFormat(IQueryable<TDto> query, int page, int pageSize)
        {
            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var result = new Page<TDto>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Rows = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        private Page<TDto> SetFormat(IList<TDto> query, int page, int pageSize)
        {
            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var result = new Page<TDto>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Rows = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        private Page<TDto> SetFormat(IEnumerable<TDto> query, int page, int pageSize)
        {
            page = page == 0 ? 1 : page;
            pageSize = pageSize == 0 ? 10 : pageSize;

            var result = new Page<TDto>();
            result.CurrentPage = page;
            result.PageSize = pageSize;
            result.RowCount = query.Count();
            var pageCount = (double)result.RowCount / pageSize;
            result.PageCount = (int)Math.Ceiling(pageCount);
            var skip = (page - 1) * pageSize;
            result.Rows = query.Skip(skip).Take(pageSize).ToList();

            return result;
        }

        private string SetOrder(List<Order> orders)
        {
            string result = string.Empty;

            for (int i = 0; i < orders.Count; i++)
            {
                result += string.Format("{0} {1} {2}", (i > 0 ? "," : ""), orders[i].OrderBy, (orders[i].Descending ? "DESC" : "ASC"));
            }

            return result;
        }
    }
}
