using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseClientTest.Services
{
    public class PerformerCertificateService : Repository<PerformerCertificate>, IPerformerCertificateService
    {
        
    }
    public interface IPerformerCertificateService: IRepository<PerformerCertificate>
    {
        
    }
}