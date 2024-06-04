using DriveCalendarBE.Entities;

namespace DriveCalendarBE.Services.Interfaces
{
    public interface IBatchService
    {
     
        int AddBatch(Batch batch);

        IEnumerable<Batch> GetAllBatches();

        Batch GetBatchById(int id);

        int DeleteBatch(int id);

        int UpdateBatch(Batch batch);


    }
}
