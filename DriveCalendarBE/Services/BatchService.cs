using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;

namespace DriveCalendarBE.Services
{
  
    public class BatchService :IBatchService
    {
        private readonly IBatchRepository repo;

        public BatchService(IBatchRepository repo)
        {
            this.repo = repo;
        }
        public int AddBatch(Batch batch)
        {
            return repo.AddBatch(batch);
        }


        public IEnumerable<Batch> GetAllBatches()
        {
            return repo.GetAllBatches();
        }

        public Batch GetBatchById(int id)
        {
            return repo.GetBatchById(id);
        }

        public int DeleteBatch(int id)
        {
            return repo.DeleteBatch(id);
        }

        public int UpdateBatch(Batch batch)
        {
            return repo.UpdateBatch(batch);
        }


    }
}
