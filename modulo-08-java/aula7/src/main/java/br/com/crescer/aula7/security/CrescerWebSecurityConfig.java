package br.com.crescer.aula7.security;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpMethod;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.annotation.web.configuration.WebSecurityConfigurerAdapter;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;

/** 
 * @author carloshenrique
 */
@EnableWebSecurity
@EnableGlobalMethodSecurity(securedEnabled = true)
public class CrescerWebSecurityConfig extends WebSecurityConfigurerAdapter {

    @Autowired
    private CrescerUserDetailsService crescerUserDetailsService;
    
    @Override
    protected void configure(HttpSecurity httpSecurity) throws Exception {
        httpSecurity
                .authorizeRequests()
                .antMatchers(HttpMethod.GET, "/ator")
                .permitAll()
                .and()
                .authorizeRequests().anyRequest().authenticated()
                .and()
                .httpBasic()
                .and()
                .logout().logoutUrl("/logout").deleteCookies("JSESSIONID").permitAll()
                .and()
                .cors().disable()
                .csrf().disable();
    }

    @Autowired
    public void setDetailsService(AuthenticationManagerBuilder auth) throws Exception {
//        auth.inMemoryAuthentication() //
//                .withUser("user").password("password").authorities("ROLE_USER") //
//                .and() //
//                .withUser("admin").password("password").authorities("ROLE_USER", "ROLE_ADMIN");
        auth.userDetailsService(crescerUserDetailsService).passwordEncoder(new BCryptPasswordEncoder());
    }
}
