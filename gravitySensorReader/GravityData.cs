﻿using System;
using System.ComponentModel;

namespace gravitySensorReader
{
    class GravityData : INotifyPropertyChanged
    {
        DateTime LastUiRefresh = DateTime.Now;
        public event PropertyChangedEventHandler PropertyChanged;


        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }

        public decimal? XMax { get; set; }
        public decimal? YMax { get; set; }
        public decimal? ZMax { get; set; }

        public decimal? XMin { get; set; }
        public decimal? YMin { get; set; }
        public decimal? ZMin { get; set; }

		public decimal? XFrequency { get; set; }
		public decimal? YFrequency { get; set; }
		public decimal? ZFrequency { get; set; }

		public decimal? XPeriod { get => ComputeAndRoundPeriod(XFrequency); }
		public decimal? YPeriod { get => ComputeAndRoundPeriod(YFrequency); }
		public decimal? ZPeriod { get => ComputeAndRoundPeriod(ZFrequency); }

        private static decimal? ComputeAndRoundPeriod(decimal? frequency)
        {
			if (frequency.HasValue && frequency != 0)
			{
				var period = 1 / frequency;
				return (decimal)Math.Round((double)period, 4);
			}
			return null;
		}

		public void SetFrequencies((decimal X, decimal Y, decimal Z) calculation)
        {
            XFrequency = Math.Round(calculation.X, 4);
			YFrequency = Math.Round(calculation.Y, 4);
			ZFrequency = Math.Round(calculation.Z, 4); 
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(XFrequency)));
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(YFrequency)));
			PropertyChanged(this, new PropertyChangedEventArgs(nameof(ZFrequency)));
		}

		public void ProcessDataPoint(decimal xDataPoint, decimal yDataPoint, decimal zDataPoint)
        {
            // Discard junk data
            if (xDataPoint == 0 || yDataPoint == 0 || zDataPoint == 0) return;

            X = xDataPoint;
            Y = yDataPoint;
            Z = zDataPoint;

            if (!XMax.HasValue || xDataPoint > XMax.Value) XMax = xDataPoint;
            if (!YMax.HasValue || yDataPoint > YMax.Value) YMax = yDataPoint;
            if (!ZMax.HasValue || zDataPoint > ZMax.Value) ZMax = zDataPoint;

            if (!XMin.HasValue || xDataPoint < XMin.Value) XMin = xDataPoint;
            if (!YMin.HasValue || yDataPoint < YMin.Value) YMin = yDataPoint;
            if (!ZMin.HasValue || zDataPoint < ZMin.Value) ZMin = zDataPoint;

            // Raise data binding events for the UI at most 10 times a second. The UI was freezing without this.
            if (new TimeSpan(DateTime.Now.Ticks - LastUiRefresh.Ticks).TotalMilliseconds > 50)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(X)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Y)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(Z)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(XMax)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(YMax)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ZMax)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(XMin)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(YMin)));
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(ZMin)));

				LastUiRefresh = DateTime.Now;
            }
        }
    }
}
