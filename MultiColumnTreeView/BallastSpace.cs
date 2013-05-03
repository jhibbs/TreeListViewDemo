using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace MultiColumnTreeView
{
    public class BallastSpace : INotifyPropertyChanged
    {

        public BallastSpace(string name)
        {
            Name = _name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Ship _parent = null;
        private string _name = "";
        private int _overflowPosition = 0;
        private ObservableCollection<SpaceChild> _children = new ObservableCollection<SpaceChild>();

        private bool _IsSelected = false;
        private bool _IsExpanded = false;

        public Ship Parent
        {
            get { return _parent; }
            set
            {
                if (_parent != value)
                {
                    _parent = value;
                    NotifyPropertyChanged("Parent");
                }
            }
        }

        public ReadOnlyObservableCollection<SpaceChild> Children
        {
            get { return new ReadOnlyObservableCollection<SpaceChild>(_children); }
        }

        public void AddChild(SpaceChild spaceChild)
        {
            _children.Add(spaceChild);
            NotifyPropertyChanged("Children");
            NotifyPropertyChanged("HasChildren");
        }

        public void RemoveChild(SpaceChild spaceChild)
        {
            _children.Remove(spaceChild);
            NotifyPropertyChanged("Children");
            NotifyPropertyChanged("HasChildren");
        }

        public bool HasChildren
        {
            get
            {
                return (_children.Count > 0);
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public int OverflowPosition
        {
            get { return _overflowPosition; }
            set
            {
                if (_overflowPosition != value)
                {
                    _overflowPosition = value;
                    NotifyPropertyChanged("OverflowPosition");
                }
            }
        }

        public int StartFrame
        {
            get
            {
                int val = int.MaxValue;

                foreach (SpaceChild sc in _children)
                {
                    val = Math.Min(sc.StartFrame, val);
                }
                return val;
            }
        }

        public int EndFrame
        {
            get
            {
                int val = int.MinValue;

                foreach (SpaceChild sc in _children)
                {
                    val = Math.Max(sc.EndFrame, val);
                }
                return val;

            }
        }

        public double TankLength
        {
            get
            {
                return 0.0;
            }
        }

        public bool IsSelected
        {
            get { return _IsSelected; }
            set
            {
                if (_IsSelected != value)
                {
                    _IsSelected = value;
                    NotifyPropertyChanged("IsSelected");
                }
            }
        }

        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                if (_IsExpanded != value)
                {
                    _IsExpanded = value;
                    NotifyPropertyChanged("IsExpended");
                }
            }
        }

    }
}
