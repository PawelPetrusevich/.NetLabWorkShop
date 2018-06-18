using FluentValidation;
using MailKit;
using MailKit.Net.Smtp;
using Ninject.Modules;
using Rocket.BL.Common.Services;
using Rocket.BL.Common.Services.Notification;
using Rocket.BL.Common.Services.PersonalArea;
using Rocket.BL.Common.Services.ReleaseList;
using Rocket.BL.Common.Services.User;
using Rocket.BL.Common.Services.UserPayment;
using Rocket.BL.Services;
using Rocket.BL.Services.Notification;
using Rocket.BL.Services.PersonalArea;
using Rocket.BL.Services.ReleaseList;
using Rocket.BL.Services.User;
using Rocket.BL.Services.UserPaymentService;
using Rocket.BL.Validators.User;
using System.Collections.Generic;

namespace Rocket.BL
{
    using Rocket.BL.Services.UserServices;

    public class BLModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ITvSeriesDetailedInfoService>().To<TvSeriesDetailedInfoService>();
            Bind<IMusicDetailedInfoService>().To<MusicDetailedInfoService>();
            Bind<IEpisodeService>().To<EpisodeService>();
            Bind<IPersonalData>().To<PersonalDataService>();
            Bind<IValidator<Common.Models.User.User>>().To<UserValidatorCheckRequiredFields>();
            Bind<IEmailManager>().To<ChangeEmailManagerService>();
            Bind<IUserPaymentService>().To<UserPaymentService>();
            this.Bind<IUserRoleManager>().To<UserRoleManager>();

            Bind<IUserAccountLevelService>().To<UserAccountLevelService>();
            Bind<IUserAccountStatusService>().To<UserAccountStatusService>();
            Bind<IUserManagementService>().To<UserManagementService>();
            this.Bind<IUserRoleService>().To<RoleService>();

            Bind<IGenreManager>().To<ChangeGenreManagerService>();
            Bind<IGenreService>().To<GenreService>();
            Bind<IMailNotificationService>().To<MailNotificationService>()
                .WithConstructorArgument(
                    "transport",
                    new List<SmtpClient>()
                    {
                        new SmtpClient(),
                        new SmtpClient(),
                        new SmtpClient(),
                        new SmtpClient()
                    });
            Bind<ISubscriptionService>().To<SubscriptionService>();
            Bind<IMailTransport>().To<SmtpClient>();
            Bind<ILogService>().To<InfoLogService>();
        }
    }
}