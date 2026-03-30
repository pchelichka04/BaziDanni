using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.zapisani_abonamenti;

namespace BaziDanni_k.p_.Forms.zapisani_abonamenti;

public sealed class ZapisaniAbonamentiForm(string cs)
    : EntityManagementForm("Управление: ZAPISANI_ABONAMENTI", new ZapisaniAbonamentiRepository(cs), "N_chlen", "N_chlen", "N_grupa", "N_abonament", "Data_zapis");
