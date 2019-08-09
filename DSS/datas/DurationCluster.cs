using Microsoft.ML.Data;

namespace DSS.datas
{
    public class AppliantDataCluster
    {
        [LoadColumn(0)]
        public float duration { get; set; }
    }
}
