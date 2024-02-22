using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.Model
{
  internal class Value
  {
    /// <summary>
    /// Текущее значение.
    /// </summary>
    public string? ValueCalc { get; set; } = "0";

    /// <summary>
    /// Промежуточное значение.
    /// </summary>
    public double Sub { get; set; }
  }
}
