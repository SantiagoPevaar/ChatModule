import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@volo/abp.ng.account/public').then(m => m.AccountPublicModule.forLazy()),
  },
  {
    path: 'identity',
    loadChildren: () => import('@volo/abp.ng.identity').then(m => m.IdentityModule.forLazy()),
  },
  {
    path: 'language-management',
    loadChildren: () =>
      import('@volo/abp.ng.language-management').then(m => m.LanguageManagementModule.forLazy()),
  },
  {
    path: 'saas',
    loadChildren: () => import('@volo/abp.ng.saas').then(m => m.SaasModule.forLazy()),
  },
  {
    path: 'audit-logs',
    loadChildren: () =>
      import('@volo/abp.ng.audit-logging').then(m => m.AuditLoggingModule.forLazy()),
  },
  {
    path: 'openiddict',
    loadChildren: () =>
      import('@volo/abp.ng.openiddictpro').then(m => m.OpeniddictproModule.forLazy()),
  },
  {
    path: 'text-template-management',
    loadChildren: () =>
      import('@volo/abp.ng.text-template-management').then(m =>
        m.TextTemplateManagementModule.forLazy()
      ),
  },
  {
    path: 'setting-management',
    loadChildren: () =>
      import('@abp/ng.setting-management').then(m => m.SettingManagementModule.forLazy()),
  },
  {
    path: 'product-service',
    loadChildren: () => import('product-service').then(m => m.ProductServiceModule),
  },
  {
    path: 'chat',
    loadChildren: () =>
      import('@volo/abp.ng.chat').then(m => m.ChatModule.forLazy(/* options here */)),
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {})],
  exports: [RouterModule],
})
export class AppRoutingModule {}
