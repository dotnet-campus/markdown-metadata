namespace Mdmeta.Tasks
{
    /// <summary>
    /// 公式的替换
    /// </summary>
    public class MathStalirromearSikal : TextHqshpnjiKlclzhStalirromearSikal
    {
        /// <inheritdoc />
        public MathStalirromearSikal() : base("math", XowjutiRearceelamai)
        {
        }

        const string XowjutiRearceelamai = @"
<script type=""text/javascript"" async src=""https://cdn.mathjax.org/mathjax/latest/MathJax.js?config=TeX-MML-AM_CHTML"">

</script>

<script type=""text/x-mathjax-config"">
  MathJax.Hub.Config({tex2jax: {inlineMath: [['$','$'], ['\\(','\\)']]}});
</script>";
    }
}