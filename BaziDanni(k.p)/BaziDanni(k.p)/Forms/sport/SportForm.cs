using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.sport;

namespace BaziDanni_k.p_.Forms.sport;

public sealed class SportForm(string cs)
    : EntityManagementForm("Управление: SPORT", new SportRepository(cs), "N_sport", "N_sport", "Ime_sport", "Cvyat");
