using System.Web.Http;
using Rocket.BL.Common.Services.UserPayment;

namespace Rocket.Web.Controllers.UserPayments
{
    using Rocket.BL.Common.Services.User;

    /// <summary>
    /// Контроллер WebApi работы с инфой о платеже.
    /// </summary>
    [RoutePrefix("userpayments")]
    public class UserPaymentsController : ApiController
    {
        private readonly IUserPaymentService _userPaymentService;

        private readonly IUserManagementService _userManagmentService;

        public UserPaymentsController(IUserPaymentService userPaymentService)
        {
            _userPaymentService = userPaymentService;
        }

        /// <summary>
        /// Возвращает информацию о платеже.
        /// </summary>
        /// <returns>Информация о платеже.</returns>
        [HttpGet]
        [Route("paymentInfo/{id:int:min(1)}")]
        public IHttpActionResult GetPaymentInfo(int id)
        {
            var user = this._userManagmentService.GetUser(id.ToString()).Result;

            if (user == null)
            {
                //TODO: get current user
                return NotFound();
            }

            var payment = _userPaymentService.GetUserPayment(user);

            if (payment == null)
            {
                return NotFound();
            }

            return Ok(payment);
        }
    }
}
