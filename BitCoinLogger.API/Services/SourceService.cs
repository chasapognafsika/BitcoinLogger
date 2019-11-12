//using System.Collections.Generic;
//using System.Linq;
//using BitcoinLogger.Api.Data;
//using BitcoinLogger.Api.Services.Shared;
//using BitcoinLogger.Api.ViewModels;
//using Microsoft.EntityFrameworkCore;

//namespace BitcoinLogger.Api.Services
//{
//    public class SourceService
//    {
//        private readonly IUnitOfWork _unitOfWork;

//        public SourceService(IUnitOfWork unitOfWork)
//        {
//            _unitOfWork = unitOfWork;
//        }

//        /// <summary>
//        ///     Returns sources available within the system.
//        /// </summary>
//        public ServiceOperationResult<IEnumerable<SourceViewModel>> GetSources()
//        {
//            var sources = _unitOfWork.Sources.GetAsQueryable();

//            return ServiceOperationResult<IEnumerable<SourceViewModel>>.Success(
//                sources.Select(s => new SourceViewModel
//                {
//                    Id = s.Id,
//                    Name = s.Name,
//                    Endpoint = s.Endpoint
//                })
//            );
//        }
//    }
//}