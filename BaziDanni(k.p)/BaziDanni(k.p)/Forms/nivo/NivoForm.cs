using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.nivo;

namespace BaziDanni_k.p_.Forms.nivo;

public sealed class NivoForm(string cs)
    : EntityManagementForm("Управление: NIVO", new NivoRepository(cs), "N_nivo", "N_nivo", "Ime_nivo", "Cvyat");
