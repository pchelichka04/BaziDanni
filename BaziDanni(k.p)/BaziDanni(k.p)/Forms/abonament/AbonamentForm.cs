using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.abonament;

namespace BaziDanni_k.p_.Forms.abonament;

public sealed class AbonamentForm(string cs)
    : EntityManagementForm("Управление: ABONAMENT", new AbonamentRepository(cs), "N_abonament", "N_abonament", "Period_meseci", "Cena_lv");
