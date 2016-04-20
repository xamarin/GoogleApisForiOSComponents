App Indexing puts your app in front of users who use Google Search. It works by indexing the URL patterns you provide in your app manifest and using API calls from your app to make content within your app available to both existing and new users. Specifically, when you support URLs for your app content, iOS users can go directly to it from Search results on their device. Finally, Google uses App Indexing API calls from your app as a ranking signal for your URLs.

## How App Indexing works for iOS

### Support HTTP URLs to your mobile app.

iOS apps support HTTP URLs and use site association to verify the relationship between the app and its website. This allows Google systems to index URLs that work for both your site and your app and to serve them in search results.

Once you associate your app to your website, Google systems quickly recognize the association and begin the crawling and discovery process for your app URLs. This can take between 24 hours and a number of days, depending on a number of factors. Because most app content is currently associated with web content, crawl scheduling works in a fashion similar to that of webpages: Google take into account multiple factors like frequency of content updates, server load, importance, and freshness of the page. Google will send you a message in Search console when content from your app shows up in search (“first impression”). If it’s been a couple weeks and you still don’t see any app links in search, check for crawl errors. Read about [Google Search crawl frequency][1] on Google Help Center.

[1]: https://support.google.com/webmasters/answer/34439

### Add the App Indexing API or SDK.

Use the App Indexing SDK for iOS 9. The use of Google SDK enhances ranking performance for the URLs and provides the basis for link titles and content snippets. This provides the titles and description snippets associated with your content, as well as the history of actions to your app. Users of your app can delete past activity in apps at https://history.google.com/.

### Check your implementation.

Test URLs to your app in your development environment to make sure they lead to the correct content.

## Technical requirements

Google App Indexing documentation for iOS 9 serves iOS universal links from Google Search in Safari. App Indexing for iOS versions 7 and 8 is now deprecated and no longer available for new integrations.