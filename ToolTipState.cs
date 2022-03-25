﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;
using System;

namespace DistributedToolTips
{
    public interface IToolTipState : IDisposable
    {
        event Action OnChange;
        void NotifyStateChanged();
        void ActivateToolTip();
        int IncrementAnchorsCount();
        bool IsActive { get; }
    }
    public class ToolTipState : IToolTipState
    {
        protected bool _toolTipsActive = false;
        public event Action OnChange;
        public void NotifyStateChanged() => OnChange?.Invoke();
        private readonly NavigationManager _navigationManager;
        private int anchorsCount;
        public ToolTipState(NavigationManager navigationManager)
        {
            _navigationManager = navigationManager;
            anchorsCount = 0;
            _navigationManager.LocationChanged += NewPage;
        }

        public void Dispose()
        {
            _navigationManager.LocationChanged -= NewPage;
        }
        protected void NewPage(object sender, LocationChangedEventArgs e)
        {
            anchorsCount = 0;
            ActivateToolTip();
        }

        public bool IsActive { get => _toolTipsActive; }
        public void ActivateToolTip()
        {
            _toolTipsActive = !_toolTipsActive;
            NotifyStateChanged();
        }
        public int IncrementAnchorsCount()
        {
            anchorsCount++;
            return anchorsCount;
        }
    }
}