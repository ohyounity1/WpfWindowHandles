using System;
using System.Windows;
using WpfApp1.Services;
using WpfApp1.ViewModels.Commands;

namespace WpfApp1.ViewModels
{
    public class LaunchedWindowViewModel : WindowedViewModelBase, ViewModelBase.IPropertyListener<IntPtr>, ViewModelBase.IPropertyListener<SyncParentWindowCommand>, ViewModelBase.IPropertyListener<bool>, IViewRenderedListener, IParentHandleListener
    {
        private readonly Property<IntPtr> _thisHandleProperty;
        private readonly Property<IntPtr> _parentHandleProperty;
        private readonly Property<IntPtr> _ownerHandleProperty;
        private readonly Property<IntPtr> _ancestorHandleProperty;
        private readonly Property<IntPtr> _originalAncestorProperty;
        private readonly Property<IntPtr> _setParentResultProperty;
        private readonly Property<bool> _parentImmediatelyProperty;

        private readonly Func<Window, IWindowHandleService> _serviceFactory;
        private IWindowHandleService _service;

        private SyncParentWindowCommand _syncParentWindowCommand;
        private UnSyncParentWindowCommand _unSyncParentWindowCommand;


        public LaunchedWindowViewModel(Func<Window, IWindowHandleService> serviceFactory)
        {
            _serviceFactory = serviceFactory;
            _thisHandleProperty = RegisterProperty(this, nameof(ThisHandle), () => IntPtr.Zero);
            _parentHandleProperty = RegisterProperty(this, nameof(ParentHandle), () => IntPtr.Zero);
            _ownerHandleProperty = RegisterProperty(this, nameof(OwnerHandle), () => IntPtr.Zero);
            _ancestorHandleProperty = RegisterProperty(this, nameof(AncestorHandle), () => IntPtr.Zero);
            _originalAncestorProperty = RegisterProperty(this, nameof(OriginalAncestor), () => IntPtr.Zero);
            _setParentResultProperty = RegisterProperty(this, nameof(SetParentResult), () => IntPtr.Zero);
            _parentImmediatelyProperty = RegisterProperty(this, nameof(ParentImmediately), () => false);
        }

        private void RefreshHandles()
        {
            ThisHandle = _service.GetHandle();
            ParentHandle = _service.GetParent();
            OwnerHandle = _service.GetOwner();
            AncestorHandle = _service.GetAncestor();
        }

        public IntPtr ThisHandle
        {
            get => _thisHandleProperty.Value;
            set => _thisHandleProperty.Value = value;
        }

        public IntPtr ParentHandle
        {
            get => _parentHandleProperty.Value;
            set => _parentHandleProperty.Value = value;
        }

        public IntPtr OwnerHandle
        {
            get => _ownerHandleProperty.Value;
            set => _ownerHandleProperty.Value = value;
        }

        public IntPtr AncestorHandle
        {
            get => _ancestorHandleProperty.Value;
            set => _ancestorHandleProperty.Value = value;
        }

        public IntPtr OriginalAncestor
        {
            get => _originalAncestorProperty.Value;
            set => _originalAncestorProperty.Value = value;
        }

        public void UpdateValue(string propertyName, IntPtr value)
        {
            OnPropertyChanged(propertyName);
        }

        protected override void OnWindowProviderUpdated(IWindowProvider provider, Func<Window, IWindowProvider> factory)
        {
            _service = _serviceFactory(provider.GetWindow());
            SyncParentWindowCommand = new SyncParentWindowCommand(_service, this);
            UnSyncParentWindowCommand = new UnSyncParentWindowCommand(_service, this);

            RefreshHandles();
        }

        protected override void OnParentImmediatelyUpdated(bool parentImmediately)
        {
            ParentImmediately = parentImmediately;
        }

        public void OnContentRendered()
        {
            _service = _serviceFactory(WindowProvider.GetWindow());
            SyncParentWindowCommand = new SyncParentWindowCommand(_service, this);
            UnSyncParentWindowCommand = new UnSyncParentWindowCommand(_service, this);
            RefreshHandles();
            OriginalAncestor = AncestorHandle;
            if(ParentImmediately)
            {
                SetParentResult = _service.SetParent(OwnerHandle);
                RefreshHandles();
            }
        }

        public void UpdateValue(string propertyName, SyncParentWindowCommand value)
        {
            OnPropertyChanged(propertyName);
        }

        public SyncParentWindowCommand SyncParentWindowCommand
        {
            get => _syncParentWindowCommand;
            set 
            {
                if(!ReferenceEquals(_syncParentWindowCommand, value))
                {
                    _syncParentWindowCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        public UnSyncParentWindowCommand UnSyncParentWindowCommand
        {
            get => _unSyncParentWindowCommand;
            set
            {
                if (!ReferenceEquals(_unSyncParentWindowCommand, value))
                {
                    _unSyncParentWindowCommand = value;
                    OnPropertyChanged();
                }
            }
        }

        public IntPtr SetParentResult 
        {
            get => _setParentResultProperty.Value;
            set
            {
                _setParentResultProperty.Value = value;
                OriginalAncestor = value;
            }
        }

        public bool ParentImmediately 
        {
            get => _parentImmediatelyProperty.Value;
            set => _parentImmediatelyProperty.Value = value;
        }

        public void UpdateHandles()
        {
            RefreshHandles();
        }

        public void UpdateValue(string propertyName, bool value)
        {
            OnPropertyChanged(propertyName);
        }
    }
}
