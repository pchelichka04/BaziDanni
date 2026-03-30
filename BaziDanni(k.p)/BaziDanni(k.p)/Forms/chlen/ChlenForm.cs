using BaziDanni_k.p_.Forms.Common;
using BaziDanni_k.p_.Repositories.chlen;

namespace BaziDanni_k.p_.Forms.chlen;

public sealed class ChlenForm(string cs)
    : EntityManagementForm("Управление: CHLEN", new ChlenRepository(cs), "N_chlen", "N_chlen", "Ime_chlen", "EGN", "Telefon", "Adres");
