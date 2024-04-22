﻿using CommunityToolkit.Mvvm.ComponentModel;
using Models;
using NetflexTARpe22.Services;
using System.Collections.ObjectModel;

namespace ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly TmdbService _tmdbService;
        public HomeViewModel(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
        }

        [ObservableProperty]
        private Media _TrendingMovie;

        public ObservableCollection<Media> TopRated { get; set; } = new();
        public ObservableCollection<Media> Trending { get; set; } = new();
        public ObservableCollection<Media> NetflixOriginals { get; set; } = new();
        public ObservableCollection<Media> ActionMovies { get; set; } = new();

        public async Task InitializeAsync()
        {
            var trendingListTask = _tmdbService.GetTrendingAsync();
            var netflixOriginalsTask = _tmdbService.GetNetflixOriginalAsync();
            var topRatedListTask = _tmdbService.GetTopRatedAsync();
            var actionListTask = _tmdbService.GetNetflixOriginalAsync();

            var medias = await Task.WhenAll(trendingListTask, 
                                            netflixOriginalsTask, 
                                            topRatedListTask, 
                                            actionListTask);

            var trendingList = medias[0];
            var netflixOriginalsList = medias[1];
            var topRatedList = medias[2];
            var actionList = medias[3];

            // Setting random trending movie from trending List to the trending Movie
            TrendingMovie = trendingList.OrderBy(t => Guid.NewGuid())
                                 .FirstOrDefault(t =>
                                    !string.IsNullOrWhiteSpace(t.DisplayTitle)
                                    && !string.IsNullOrWhiteSpace(t.Thumbnail));

            SetMediaCollection(trendingList, Trending);
            SetMediaCollection(netflixOriginalsList, NetflixOriginals);
            SetMediaCollection(topRatedList, TopRated);
            SetMediaCollection(actionList, ActionMovies);

            if (trendingList?.Any() == true)
            {
                foreach (var trending in trendingList)
                {
                    Trending.Add(trending);
                }
            }

            if(netflixOriginalsList?.Any() == true)
            {
                foreach (var original in netflixOriginalsList)
                {
                    NetflixOriginals.Add(original);
                }
            }
        }
        private void SetMediaCollection(IEnumerable<Media> medias, ObservableCollection<Media> collection)
        {
            collection.Clear();
            //foreach
        }
    }
}