using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Information_Page.AppInfo.Application;
using System.Collections.Generic;

namespace Information_Page.AppInfo
{
    public class ApplicationList
    {

        public List<AppDetail> AppList
            = new List<AppDetail>() {
            new AppDetail() { Icon="AppInfo/Images/NinjAcademy.png", Title="NinjAcademy", URL="http://www.windowsphone.com/en-us/apps/2bbb733b-0c8c-46b6-8311-ea70aa4edab6", MarketplaceID="2bbb733b-0c8c-46b6-8311-ea70aa4edab6", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Translator.png", Title="Translator", URL="http://www.windowsphone.com/en-us/apps/55ef33e5-fb46-45e7-a6b1-6ef3206e4620", MarketplaceID="55ef33e5-fb46-45e7-a6b1-6ef3206e4620", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Massager.png", Title="Massager", URL="http://www.windowsphone.com/en-US/apps/d6208dc3-536e-4ecc-91f6-c083f09c2c95", MarketplaceID="d6208dc3-536e-4ecc-91f6-c083f09c2c95", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/GPS.png", Title="GPS Suite", URL="http://www.windowsphone.com/en-US/apps/b6eafd0b-f2d2-4d44-a93a-fce3f0c19517", MarketplaceID="b6eafd0b-f2d2-4d44-a93a-fce3f0c19517", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="Where Am I", URL="http://www.windowsphone.com/en-US/apps/1cb69d1a-d96c-4387-bc4d-14b13d453ed1", MarketplaceID="1cb69d1a-d96c-4387-bc4d-14b13d453ed1", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Traffic.png", Title="Traffic", URL="http://www.windowsphone.com/en-US/apps/f8dab8b2-4d5c-42ec-b7e7-49a29e75e8d0", MarketplaceID="f8dab8b2-4d5c-42ec-b7e7-49a29e75e8d0", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/WolframAlpha Prism.png", Title="WolframAlpha Prism", URL="http://www.windowsphone.com/en-US/apps/0c2b3c14-b452-441d-8918-c8fcaa58df6e", MarketplaceID="0c2b3c14-b452-441d-8918-c8fcaa58df6e", Earning="Free", Description="Search Wolfram Alpha with this dedicated browser. You can share the pages with your friends and bookmark pages." },
            new AppDetail() { Icon="AppInfo/Images/Calculator.png", Title="Calculator", URL="http://www.windowsphone.com/en-US/apps/8859f3f5-e79e-e011-986b-78e7d1fa76f8", MarketplaceID="8859f3f5-e79e-e011-986b-78e7d1fa76f8", Earning="Free", Description="" },
            new AppDetail() { Icon="AppInfo/Images/Blackjack.png", Title="Blackjack", URL="http://www.windowsphone.com/en-US/apps/8ed9d8f2-dd7a-4884-9c9f-dd8f827da7a2", MarketplaceID="8ed9d8f2-dd7a-4884-9c9f-dd8f827da7a2", Earning="Free", Description="Full featured blackjack game. Place your bets!" },
            new AppDetail() { Icon="AppInfo/Images/Memory Madness.png", Title="Memory Madness", URL="http://www.windowsphone.com/en-US/apps/1b958cb2-ca46-4e26-b19b-aa47306098eb", MarketplaceID="1b958cb2-ca46-4e26-b19b-aa47306098eb", Earning="Free", Description="Repeat the patterns of the blinking orbs before the buzzer sounds to make a new high score!" },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="Car Locator", URL="http://www.windowsphone.com/en-US/apps/bc073b6c-a4f3-48ce-bc5c-a08c6560c6ca", MarketplaceID="bc073b6c-a4f3-48ce-bc5c-a08c6560c6ca", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Toddler Color Game.png", Title="Toddler Color Game", URL="http://www.windowsphone.com/en-US/apps/cbba7d81-26da-4dbf-955c-66e9681b6247", MarketplaceID="cbba7d81-26da-4dbf-955c-66e9681b6247", Earning="Free", Description="Educational color matching game for toddlers to learn colors by text and speech." },
            new AppDetail() { Icon="AppInfo/Images/Starcraft.png", Title="Starcraft 2 Counters", URL="http://www.windowsphone.com/en-US/apps/26d99fb3-91aa-4f53-8edc-7a6d12951977", MarketplaceID="26d99fb3-91aa-4f53-8edc-7a6d12951977", Earning="Free", Description="Starcraft 2 Counters will increase your gaming ability by showing unit strengths and weaknesses of all races." },
            new AppDetail() { Icon="AppInfo/Images/CIDR Calculator.png", Title="CIDR Calculator", URL="http://www.windowsphone.com/en-US/apps/eb73783e-067d-4535-aeca-76250206e5f6", MarketplaceID="eb73783e-067d-4535-aeca-76250206e5f6", Earning="Free", Description="The CIDR Calculator enables CIDR network calculations using IP address, subnet mask, mask bits, maximum required IP addresses and maximum required subnets." },
            new AppDetail() { Icon="AppInfo/Images/Starcraft.png", Title="SC2 Build Order", URL="http://www.windowsphone.com/en-US/apps/0bf15c47-053e-44b3-bb53-dd1587bb0b1d", MarketplaceID="0bf15c47-053e-44b3-bb53-dd1587bb0b1d", Earning="Free", Description="Starcraft 2 Build Order can help improve your skills and can plan your game strategy." },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="todo GPS", URL="http://www.windowsphone.com/en-US/apps/e6b4f8d7-bbd4-4057-afa5-ae623e7e819b", MarketplaceID="e6b4f8d7-bbd4-4057-afa5-ae623e7e819b", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Unit Converter.png", Title="Unit Converter", URL="http://www.windowsphone.com/en-US/apps/3bc20907-99f2-4d86-a9f6-6b622a5951a1", MarketplaceID="3bc20907-99f2-4d86-a9f6-6b622a5951a1", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/chmod.png", Title="chmod", URL="http://www.windowsphone.com/en-US/apps/1a4249ed-d04e-4cc5-a272-b76c8eeb0337", MarketplaceID="1a4249ed-d04e-4cc5-a272-b76c8eeb0337", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="Ringtone Reminder", URL="http://www.windowsphone.com/en-US/apps/fef37cbe-fa91-4a33-8984-1650567b9904", MarketplaceID="fef37cbe-fa91-4a33-8984-1650567b9904", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Road Rage.png", Title="Road Rage", URL="http://www.windowsphone.com/en-US/apps/2bb8933a-c47c-44bc-bf9c-fff2dfde8afb", MarketplaceID="2bb8933a-c47c-44bc-bf9c-fff2dfde8afb", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/umask.png", Title="umask", URL="http://www.windowsphone.com/en-US/apps/e2a21741-3606-4b3e-9d72-65b0f289ba68", MarketplaceID="e2a21741-3606-4b3e-9d72-65b0f289ba68", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Tip.png", Title="Tip", URL="http://www.windowsphone.com/en-US/apps/6ccd192d-1ebc-42f2-8236-d15227f2719e", MarketplaceID="6ccd192d-1ebc-42f2-8236-d15227f2719e", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/What's Your Blues Name.png", Title="What's Your Blues Name", URL="http://www.windowsphone.com/en-US/apps/67fc9733-18eb-4eca-beea-8f43890f0397", MarketplaceID="67fc9733-18eb-4eca-beea-8f43890f0397", Earning="Free" },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="GPS Suite", URL="http://www.windowsphone.com/en-US/apps/6cbc7e19-305e-4c45-a82a-c472170e8fa0", MarketplaceID="6cbc7e19-305e-4c45-a82a-c472170e8fa0", Earning="$1.29" },
            new AppDetail() { Icon="AppInfo/Images/Traffic.png", Title="Traffic", URL="http://www.windowsphone.com/en-US/apps/c115d5a3-d2fc-41ed-82d3-b5f895892ef5", MarketplaceID="c115d5a3-d2fc-41ed-82d3-b5f895892ef5", Earning="$0.99" },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="todo GPS", URL="http://www.windowsphone.com/en-US/apps/c3fd0e33-d35a-4e27-9731-f614ec5b5db6", MarketplaceID="c3fd0e33-d35a-4e27-9731-f614ec5b5db6", Earning="$0.99" },
            new AppDetail() { Icon="AppInfo/Images/CIDR Calculator.png", Title="CIDR Calculator", URL="http://www.windowsphone.com/en-US/apps/e3a94bc5-3cc4-4d0e-8c48-7a6f6bfe4a9c", MarketplaceID="e3a94bc5-3cc4-4d0e-8c48-7a6f6bfe4a9c", Earning="$0.99", Description="The CIDR Calculator enables CIDR network calculations using IP address, subnet mask, mask bits, maximum required IP addresses and maximum required subnets." },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="Where Am I", URL="http://www.windowsphone.com/en-US/apps/aa33174f-61ce-4fc1-a9fb-6cad69b7c128", MarketplaceID="aa33174f-61ce-4fc1-a9fb-6cad69b7c128", Earning="$0.99" },
            new AppDetail() { Icon="AppInfo/Images/Where Am I.png", Title="Car Locator", URL="http://www.windowsphone.com/en-US/apps/0a117607-6c6d-4cc7-b3b5-e075f3f1846c", MarketplaceID="0a117607-6c6d-4cc7-b3b5-e075f3f1846c", Earning="$0.99" },
        };


        public ApplicationList()
        {

        }


    }
}
