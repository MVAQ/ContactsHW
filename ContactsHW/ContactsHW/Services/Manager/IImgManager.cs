using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ContactsHW.Services.Manager
{
    public interface IImgManager
    {
        Task<string> PathImgContactOfGallerey();
        Task<string> PathImgContactOfCamera();
    }
}
