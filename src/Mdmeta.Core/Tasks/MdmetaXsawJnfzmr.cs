namespace Mdmeta.Tasks
{
    /// <summary>
    /// 提供基类，用于读取，暂时不知道名字
    /// </summary>
    public abstract class MdmetaXsawJnfzmr
    {
        /// <summary>
        /// 优先级
        /// </summary>
        public int Priority { get; set; } = 0;

        public string Line { get; set; } = "\r\n";

        /// <summary>
        /// 表示已经读过
        /// </summary>
        public bool ReadCsfLvi { get; set; } = true;

        /// <summary>
        /// 读取
        /// </summary>
        /// <returns></returns>
        public abstract void Read(NghtsBdlbthhur nghtsBdlbthhur);

        public HvjEthpiaca HvjEthpiaca { get; set; }
    }
}