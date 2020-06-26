using Microsoft.EntityFrameworkCore;
using ParaglidingProject.Data;
using ParaglidingProject.SL.Core.Helpers;
using ParaglidingProject.SL.Core.TraineeshipPayement.NS.TransferObjects;
using ParaglidingProject.SL.Core.TraineeshipPayment.NS.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParaglidingProject.SL.Core.TraineeshipPayement.NS
{
    public class TraineeshipPaymentService : ITraineeshipPaymentService
    {
        private readonly ParaglidingClubContext _paraContext;
        
       
        
        public TraineeshipPaymentService(ParaglidingClubContext paraContext)
        {
            _paraContext = paraContext ?? throw new ArgumentNullException(nameof(paraContext));
        }

        /// <inheritdoc/>
        public async Task<IReadOnlyCollection<TraineeshipPaymentDto>> GetAllTraineeshipPaymentAsync(TraineeshipPaymentSSFP options)
        {
            var traineeshipPayments = _paraContext.TraineeshipPayments
                .SearchTraineeshipPaymentBy(options)
                .AsNoTracking()
                .SortTraineeshipPaymentBy(options.SortBy)
                .FilterTraineeshipPaymentBy(options.FilterBy, options)
                .Select(p => new TraineeshipPaymentDto
                {
                   PilotId = p.PilotID,
                   TraineeshipID = p.TraineeshipID,
                   PaymentDate = p.PaymentDate,
                   IsPaid = p.IsPaid
                });

            options.SetPagingValues(traineeshipPayments);

            var pagedQuery = traineeshipPayments.Page(options.PageNumber - 1, options.PageSize);



            return await pagedQuery.ToListAsync();
        }

        /// <inheritdoc/>
        public async Task<TraineeshipPaymentDto> GetTraineeshipPaymentAsync(int pilotId, int traineeshipId)
        {
            var traineeshipPayment = await _paraContext.TraineeshipPayments
                    .AsNoTracking()
                    .Select(p => new TraineeshipPaymentDto
                    {

                        PilotId = p.PilotID,
                        TraineeshipID = p.TraineeshipID,
                        PaymentDate = p.PaymentDate,
                        IsPaid = p.IsPaid
                    })
                    .FirstOrDefaultAsync(p => p.PilotId == pilotId && p.TraineeshipID == traineeshipId);

            return traineeshipPayment;
        }
    }
}
