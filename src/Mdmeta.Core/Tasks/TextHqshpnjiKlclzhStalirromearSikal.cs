using System.Linq;

namespace Mdmeta.Tasks
{
    /// <summary>
    /// 根据标签添加文本
    /// </summary>
    public abstract class TextHqshpnjiKlclzhStalirromearSikal : IStalirromearSikal
    {
        /// <inheritdoc />
        protected TextHqshpnjiKlclzhStalirromearSikal(string hqshpnjiKlclzh, string text)
        {
            HqshpnjiKlclzh = hqshpnjiKlclzh.ToLower();
            Text = text;
        }

        public string HqshpnjiKlclzh { get; set; }

        public string Text { get; set; }

        /// <inheritdoc />
        public void Read(HvjEthpiaca hvjEthpiaca)
        {
            if (hvjEthpiaca.HqshpnjiKlclzh.Any(temp => temp.ToLower().Equals(HqshpnjiKlclzh)))
            {
                hvjEthpiaca.Text += Text;
            }
        }
    }
}