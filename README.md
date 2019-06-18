# Siteore Speedy
Sitecore Speedy - Use best practice page load techniques to achieve excellent Page Speed scores.

SXA Version

Description

This is a Sitecore Helix module that incorporates best practice layout HTML structures in order in an attempt to maximiuse the scores achievable in Google Page Speed Insights.

Page Speed is an important metric of a websites performance and has a big impact on SEO and a sites Google ranking. 

Optimising your site for great page speed scores could involve:

1) Server Side caching  (impact the Time to First Byte (TTFB) metric)
2) Image optimiisation (Loseless compression), Image Lazy Loading, Responsive images
3) Critical CSS and Defered external asset files
4) HTTP2

Read more here ...

This module addresses Critical CSS and Deferred asset loading, which is perhaps the hardest one to get right. 

Installation - From Helix Source - Assumes Unicorn is in use

1) Incorporate the module into your Foundation layer and VS solution
2) Publish project to your running IIS site or deploy via CI/CD
3) Run a unicorn sync for the module Foundation.Speedy
	a) Templates will be installed here: /sitecore/templates/Foundation/Speedy/
	b) A global settings file is installed here:  /sitecore/system/Settings/Foundation/Speedy/Speedy Global Settings
	c) A new SXA Layout will be installed here: /sitecore/layout/Layouts/Foundation/Speedy/MVC/MVC Layout Page Speed
4) Update


