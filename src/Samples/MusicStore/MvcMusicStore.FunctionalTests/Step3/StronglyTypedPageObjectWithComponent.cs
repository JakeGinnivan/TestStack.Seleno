﻿using MvcMusicStore.FunctionalTests.Step3.Pages;
using NUnit.Framework;
using FluentAssertions;

namespace MvcMusicStore.FunctionalTests.Step3
{
    public class StronglyTypedPageObjectWithComponent
    {
        [Test]
        public void Can_buy_an_Album_when_registered()
        {
            var orderedPage = new HomePage()
                .Menu
                .GoToAdminForAnonymousUser()
                .GoToRegisterPage()
                .CreateValidUser(ObjectMother.CreateRegisterModel())
                .GenreMenu
                .SelectGenreByName("Disco")
                .SelectAlbumByName("Le Freak")
                .AddAlbumToCart()
                .Checkout()
                .SubmitShippingInfo(ObjectMother.CreateShippingInfo(), "Free");

            orderedPage.Title.Should().Be("Checkout Complete");
        }
    }
}
