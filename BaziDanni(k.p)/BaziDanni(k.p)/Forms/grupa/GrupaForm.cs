using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.grupa;

namespace BaziDanni_k.p_.Forms.grupa;

public sealed class GrupaForm(string cs)
    : EntityManagementForm("Управление: GRUPA", new GrupaRepository(cs), "N_grupa", "N_grupa", "N_sport", "N_nivo", "N_trenior");
