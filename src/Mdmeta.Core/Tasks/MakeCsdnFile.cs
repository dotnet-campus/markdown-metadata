namespace Mdmeta.Tasks
{
    public class MakeCsdnFile : IMakeFileName
    {
        /// <inheritdoc />
        public string MakeFileName(HvjEthpiaca hvjEthpiaca)
        {
            string str = hvjEthpiaca.Title;

            str = ValidFileName.MakeValidFileName(str);
            return str;
        }
    }
}