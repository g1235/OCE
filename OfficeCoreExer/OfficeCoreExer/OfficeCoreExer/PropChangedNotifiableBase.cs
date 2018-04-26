using System.Collections.Generic;
using System.ComponentModel;

public class PropChangedNotifiableBase : INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;
    public void SetProperty<T>(ref T field, T value, string name)
    {
        try
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        catch (System.Exception ex)
        {

          //  throw;
        }
    }

    public void RaisePropChanged(string propname)
    {
        try
        {
            if (PropertyChanged != null) // for use not from set-property
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }
        }
        catch (System.Exception ex)
        {

            //throw;
        }

    }
}
