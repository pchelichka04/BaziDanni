using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.den_sedmica;

namespace BaziDanni_k.p_.Forms.den_sedmica;

public sealed class DenSedmicaForm(string cs)
    : EntityManagementForm("Управление: DEN_SEDMICA", new DenSedmicaRepository(cs), "N_den", "N_den", "Den", "Cvyat");
