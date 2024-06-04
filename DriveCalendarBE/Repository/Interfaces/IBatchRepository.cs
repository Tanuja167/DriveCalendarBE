
using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Repository.Interfaces
{
    public interface IBatchRepository
    { 
        int AddBatch(Batch batch);
        IEnumerable<Batch> GetAllBatches();

        Batch GetBatchById(int id);

        int DeleteBatch(int id);

        int UpdateBatch(Batch batch);



    }
}
