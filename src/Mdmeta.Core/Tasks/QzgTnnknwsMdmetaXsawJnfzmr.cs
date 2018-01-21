namespace Mdmeta.Tasks
{
    public class QzgTnnknwsMdmetaXsawJnfzmr : MdmetaXsawJnfzmr
    {
        /// <summary>
        /// 用于一般转换，读到什么就转什么
        /// </summary>
        public QzgTnnknwsMdmetaXsawJnfzmr()
        {
        }

        public override void Read(NghtsBdlbthhur nghtsBdlbthhur)
        {
            nghtsBdlbthhur.Text = nghtsBdlbthhur.Str + Line;
        }
    }
}