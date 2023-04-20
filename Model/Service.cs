using System;

namespace Model;

public class Service
{
    public int ServiceReferenceId { get; set; }
    public DateTime ServiceDate { get; set; }
    public string ServiceDescription { get; set; }
    public string ServiceWorkerName { get; set; }

    public Service()
    {

    }

    public Service(int serviceReferenceId, DateTime serviceDate, string serviceDescription, string serviceWorkerName)
    {
        this.ServiceReferenceId = serviceReferenceId;
        this.ServiceDate = serviceDate;
        this.ServiceDescription = serviceDescription;
        this.ServiceWorkerName = serviceWorkerName;
    }
}
