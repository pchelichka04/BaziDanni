using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.trenirovka;

namespace BaziDanni_k.p_.Forms.trenirovka;

public sealed class TrenirovkaForm(string cs)
    : EntityManagementForm("Управление: TRENIROVKA", new TrenirovkaRepository(cs), "N_grupa", "N_grupa", "datata", "chas", "N_chlen", "N_den");
