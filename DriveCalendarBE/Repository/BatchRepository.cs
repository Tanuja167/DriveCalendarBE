using DriveCalendarBE.Entities;
using DriveCalendarBE.Repository.Interfaces;

namespace DriveCalendarBE.Repository
{
    public class BatchRepository : IBatchRepository
    {
        private readonly ApplicationDbContext _context;

        public BatchRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public int AddBatch(Batch batch)
        {
            int result = 0;
            //Code Added
            batch.CreatedDate = DateTime.Now;
            batch.IsActive = 1;
            _context.Batchs.Add(batch);
            result = _context.SaveChanges();
            return result;
        }

        public IEnumerable<Batch> GetAllBatches()
        {
            var batchList =
                from batch in _context.Batchs
                join t in _context.technologies on batch.TechnologyId equals t.TechnologyId
                where batch.IsActive==1
                select new Batch
                {
                    BatchId = batch.BatchId,
                    BatchName = batch.BatchName,
                    TechnologyId = batch.TechnologyId,
                    TechnologyName = t.TechnologyName,
                    IsActive = batch.IsActive
                };
            return batchList;
        }
        public int DeleteBatch(int id)
        {
            int result = 0;
            var stud = _context.Batchs.Where(x => x.BatchId == id).FirstOrDefault();
            if (stud != null)
            {
                stud.IsActive = 0;
                result = _context.SaveChanges();
            }
            return result;
        }

        public Batch GetBatchById(int id)
        {
            var batch = _context.Batchs.Where(x => x.BatchId == id).FirstOrDefault();
            return batch;
        }

        public int UpdateBatch(Batch batch)
        {
            int result = 0;
            //Anjali Buddhe(Added Datetime and Created By)
            DateTime createdDate = DateTime.Now;
            var batchInfo = _context.Batchs.Where(x => x.BatchId == batch.BatchId).FirstOrDefault();
            // var batchInfo = _context.Batchs.Where(x => x.BatchName != batch.BatchName).FirstOrDefault();
            bool isduplicate = _context.Batchs.Any(x => x.BatchName == batch.BatchName && x.IsActive == 1);

            if (!isduplicate)
            {
               
                batchInfo.BatchName = batch.BatchName;
              
              //  
                batchInfo.TechnologyId = batch.TechnologyId;
                batchInfo.CreatedDate = createdDate;
                batchInfo.CreatedBy = batch.CreatedBy;
                batchInfo.IsActive = 1;
                result = _context.SaveChanges();
            }
           
            return result;
        }


    }
}
