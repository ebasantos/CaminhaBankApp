using Microsoft.ML.Data;

namespace Model
{
    public class AppliantDataCluster
    {
        [LoadColumn(0)]
        public float age { get; set; }
        [LoadColumn(1)]
        public float education { get; set; }
        [LoadColumn(2)]
        public float housing { get; set; }
        [LoadColumn(3)]
        public float loan { get; set; }
        [LoadColumn(4)]
        public float duration { get; set; }
        [LoadColumn(5)]
        public float empratevar { get; set; }
        [LoadColumn(6)]
        public float consconfid { get; set; }
        [LoadColumn(6)]

        public float y { get; set; }
    }
}