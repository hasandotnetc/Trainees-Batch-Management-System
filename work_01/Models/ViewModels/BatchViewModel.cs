namespace work_01.Models.ViewModels
{
    public class BatchViewModel
    {
        public int SelectedBatch { get; set; }
        public IEnumerable<Batch> Batches { get; set; }
        public IEnumerable<Trainee> Trainees { get; set; }
    }

}
