using GeneratePass.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GeneratePass.ViewModels
{
  internal class SymbolViewModel : INotifyPropertyChanged
  {
    public event PropertyChangedEventHandler? PropertyChanged;

    SymbolModel symbolModel = new SymbolModel();

    public int LengthPassword
    {
      get => symbolModel.LengthPassword;
      set
      {
        symbolModel.LengthPassword = value;
        OnPropertyChanged();
      }
    }

    public char[] LowerChars
    {
      get => symbolModel.lowerChars!;
    }

    public char[] UpperChars
    {
      get => symbolModel.UpperChars!;
    }

    public char[] Symbols
    {
      get => symbolModel.Symbols!;
    }

    public void OnPropertyChanged([CallerMemberName] string prop="")
    {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
  }
}
