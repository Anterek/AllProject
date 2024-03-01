using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate.ViewModels
{
  internal class ValueViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    Model.Value value = new Model.Value();

    public string Value
    {
      get => value.ValueCalc;
      set
      {
        this.value.ValueCalc = value;
        OnPropertyChanged();
      }
    }

    public double Sub
    {
      get => value.Sub;
      set
      {
        this.value.Sub = value;
        OnPropertyChanged();
      }
    }

    public void OnPropertyChanged([CallerMemberName] string prop="")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
  }
}
