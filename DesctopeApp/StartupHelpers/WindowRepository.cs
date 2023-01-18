using DesctopeApp.Dialogs;
using DesctopeApp.RoleWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesctopeApp.StartupHelpers
{
    public class WindowRepository
    {
        public WindowRepository(
            IAbstractWindowFactory<RegistrePatientWindow> regPatientFactory,
            IAbstractWindowFactory<RegistreWorkerWindow> regWorkerFactory,
            IAbstractWindowFactory<LoginWindow> loginFactory,
            IAbstractWindowFactory<ChoseRegWindow> ChoseRegFactory,
            IAbstractWindowFactory<AdminWindow> adminFactory,
            IAbstractWindowFactory<AssistantWIndow> assistantFactory,
            IAbstractWindowFactory<AccountantWindow> accountantWindow,
            IAbstractWindowFactory<AddBiomaterialDialog> biomaterialDialog,
            IAbstractWindowFactory<PatientWindow> patientFActory
            )
        {
            RegPatientFactory = regPatientFactory;
            RegWorkerFactory = regWorkerFactory;
            LoginFactory = loginFactory;
            this.ChoseRegFactory = ChoseRegFactory;
            AdminFactory = adminFactory;
            AssistantFactory = assistantFactory;
            AccountantWindow = accountantWindow;
            BiomaterialDialog = biomaterialDialog;
            PatientFActory = patientFActory;
        }

        public IAbstractWindowFactory<RegistrePatientWindow> RegPatientFactory { get; }
        public IAbstractWindowFactory<RegistreWorkerWindow> RegWorkerFactory { get; }
        public IAbstractWindowFactory<LoginWindow> LoginFactory { get; }
        public IAbstractWindowFactory<ChoseRegWindow> ChoseRegFactory { get; }
        public IAbstractWindowFactory<AdminWindow> AdminFactory { get; }
        public IAbstractWindowFactory<AssistantWIndow> AssistantFactory { get; }
        public IAbstractWindowFactory<AccountantWindow> AccountantWindow { get; }
        public IAbstractWindowFactory<AddBiomaterialDialog> BiomaterialDialog { get; }
        public IAbstractWindowFactory<PatientWindow> PatientFActory { get; }
    }
}
