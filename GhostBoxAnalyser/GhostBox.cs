using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GhostBoxAnalyser
{
    class GhostBox : INotifyPropertyChanged
    {
        private RadioType _radioType;
        private int _volume = 100;
        private double _minFrequency;
        private double _maxFrequency;
        private int _interval;
        private double _filter;
        private double _currentFrequency;
        private int _recordTime;
        private bool _isRunning = false;

        public event PropertyChangedEventHandler PropertyChanged;

        #region Properties
        public RadioType RadioType
        {
            get { return _radioType; }
            set { _radioType = value; }
        }

        public int Volume
        {
            get { return _volume; }
            set { _volume = value; }
        }

        public double MinFrequency
        {
            get { return _minFrequency; }
            set { _minFrequency = value; }
        }

        public double MaxFrequency
        {
            get { return _maxFrequency; }
            set { _maxFrequency = value; }
        }
        public int Interval
        {
            get { return _interval; }
            set { _interval = value; }
        }

        public double Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        public double CurrentFrequency
        {
            get { return _currentFrequency; }
            set { _currentFrequency = value; }
        }

        public int RecordTime
        {
            get { return _recordTime; }
            set { _recordTime = value; }
        }
        #endregion


        public void Start()
        {
            _isRunning = true;

            while (_isRunning)
            {
                new Thread(() => HandleTick(this)).Start();
                Thread.Sleep(Interval);
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }

        public static void HandleTick(GhostBox gb)
        {
            int playStart = Convert.ToInt32(Math.Round((double)((gb.RecordTime / 2) - (gb.Interval / 2))));
            double currFreq = gb.CurrentFrequency;
            WebSdrHandler.Record(gb.CurrentFrequency, gb.Filter);
            Thread.Sleep(playStart);
            WebSdrHandler.Play(gb.CurrentFrequency, gb.Filter);
        }

        public void RaisePropertyChanged(string property)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
