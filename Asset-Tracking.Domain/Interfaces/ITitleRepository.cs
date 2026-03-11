using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Asset_Tracking.Domain.Entities;

namespace Asset_Tracking.Domain.Interfaces
{
    public interface ITitleRepository
    {
        Task<TitleEntity?> AddAsync(TitleEntity titleEntity, CancellationToken ct = default);
        Task<TitleEntity?> UpdateAsync(int id, TitleEntity titleEntity, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
        Task<TitleEntity?> GetByIdAsync(int id);
    }
}
