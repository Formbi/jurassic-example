ServiceBuilder
    .serviceName("service name")
    .displayName("display name")
    .desiredAccess(AccessRight.GenericWrite | AccessRight.GenericRead)
    .serviceType(ServiceType.Win32ShareProcess)
    .startType(StartType.SystemStart)
    .errorControl(ErrorControl.Critical)
    .createService();