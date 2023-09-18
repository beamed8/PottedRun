// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;
// using UnityEngine.UI;
// using Cysharp.Threading.Tasks;
// using Solana.Unity.Rpc.Types;
// using Solana.Unity.Wallet;

// namespace Solana.Unity.SDK.Example
// {
//     public class PhantomWalletConnection : SimpleScreen
//     {
//         [SerializeField]
//         private Button loginBtnPhantom;
//         [SerializeField]
//         private Button logoutBtn;
//         [SerializeField]
//         private GameObject tokenItem;
//         [SerializeField]
//         private Transform tokenContainer;

//         private List<TokenItem> _instantiatedTokens = new();

//         void Start()
//         {
//             PhantomFirstCheck();
//             loginBtnPhantom.onClick.AddListener(LoginCheckerPhantom);

//             logoutBtn.onClick.AddListener(() =>
//            {
//                Web3.Instance.Logout();
//                Debug.Log("Logged out.");
//                PlayerPrefs.SetInt("phantomwallet", 0);
//                CharacterUnlockBools.instance.LockAll();
//                CharacterUnlocker.instance.DisableAllCharacters();
//            });
//         }

//         private void PhantomFirstCheck()
//         {
//             if (CharacterUnlockBools.instance.firstCheck == false)
//             {
//                 loginBtnPhantom.gameObject.SetActive(true);
//             }
//             else
//             {
//                 loginBtnPhantom.gameObject.SetActive(false);
//             }
//         }

//         private async void LoginCheckerPhantom()
//         {
//             var account = await Web3.Instance.LoginPhantom();
//             CheckAccount(account);
//         }

//         private async void CheckAccount(Account account)
//         {
//             if (account != null)
//             {
//                 LevelManager.instance.EnableWallet();
//                 Debug.Log("Logged in.");
//                 await GetOwnedTokenAccounts();
//             }
//             else
//             {
//                 Debug.Log("Not logged in.");
//             }
//         }

//         private async UniTask GetOwnedTokenAccounts()
//         {
//             LevelManager.instance.SetWalletText("Connecting...");
//             CharacterUnlockBools.instance.firstCheck = true;

//             var tokens = await Web3.Base.GetTokenAccounts(Commitment.Confirmed);
//             // Remove tokens not owned anymore and update amounts
//             var tkToRemove = new List<TokenItem>();
//             _instantiatedTokens.ForEach(tk =>
//             {
//                 var tokenInfo = tk.TokenAccount.Account.Data.Parsed.Info;
//                 var match = tokens.Where(t => t.Account.Data.Parsed.Info.Mint == tokenInfo.Mint).ToArray();
//                 if (match.Length == 0 || match.Any(m => m.Account.Data.Parsed.Info.TokenAmount.AmountUlong == 0))
//                 {
//                     tkToRemove.Add(tk);
//                     Destroy(tk.gameObject);
//                     _instantiatedTokens.Remove(tk);
//                 }
//                 else
//                 {
//                     var newAmount = match[0].Account.Data.Parsed.Info.TokenAmount.UiAmountString;
//                     tk.UpdateAmount(newAmount);
//                 }
//             });
//             tkToRemove.ForEach(tk => _instantiatedTokens.Remove(tk));
//             // Add new tokens
//             if (tokens is { Length: > 0 })
//             {
//                 var tokenAccounts = tokens.OrderByDescending(
//                     tk => tk.Account.Data.Parsed.Info.TokenAmount.AmountUlong);
//                 foreach (var item in tokenAccounts)
//                 {
//                     if (!(item.Account.Data.Parsed.Info.TokenAmount.AmountUlong > 0)) break;
//                     if (_instantiatedTokens.All(t => t.TokenAccount.Account.Data.Parsed.Info.Mint != item.Account.Data.Parsed.Info.Mint))
//                     {
//                         var tk = Instantiate(tokenItem, tokenContainer, true);
//                         tk.transform.localScale = Vector3.one;

//                         PlayerPrefs.SetInt("phantomwallet", 1);

//                         Nft.Nft.TryGetNftData(item.Account.Data.Parsed.Info.Mint,
//                             Web3.Instance.Wallet.ActiveRpcClient).AsUniTask().ContinueWith(nft =>
//                         {
//                             TokenItem tkInstance = tk.GetComponent<TokenItem>();
//                             HashlistController.instance.CompareAllHashlists(nft.metaplexData.mint);
//                         }).Forget();
//                     }
//                 }
//                 PhantomFirstCheck();
//             }

//         }
//     }
// }